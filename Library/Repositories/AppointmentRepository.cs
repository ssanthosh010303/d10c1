/*
 * Author: Sakthi Santhosh
 * Created on: 17/04/2024
 */
using Challenge1.Library.Exceptions;
using Challenge1.Library.Models;

namespace Challenge1.Library.Repositories;

public interface IAppointmentRepository
{
    Appointment GetById(int id);
    List<Appointment> GetAll();
    public void Schedule(int id, Doctor doctor, Patient patient, DateTime appointmentDateTime);
    public void UpdateSchedule(int id, DateTime appointmentDateTime);
    public void Unschedule(int id);
}

public class AppointmentRepository : IAppointmentRepository
{
    private readonly List<Appointment> _appointments;

    public AppointmentRepository()
    {
        _appointments = [];
    }

    public Appointment GetById(int id)
    {
        var appointment = _appointments.Find(appointmentAtIndex => appointmentAtIndex.Id == id) ?? throw new AppointmentNotFoundException(id);

        return appointment;
    }

    public List<Appointment> GetAll()
    {
        return _appointments;
    }

    public void Schedule(int id, Doctor doctor, Patient patient, DateTime appointmentDateTime)
    {
        if (!_appointments.Any(appointmentAtIndex => appointmentAtIndex.Id == id))
        {
            var appointment = new Appointment { Id = id, Doctor = doctor, Patient = patient, AppointmentDateTime = appointmentDateTime };

            appointment.Doctor.SetAppointment(appointment);
            _appointments.Add(appointment);
        }
        else
        {
            throw new AppointmentAlreadyExistsException(id);
        }
    }

    public void UpdateSchedule(int id, DateTime appointmentDateTime)
    {
        var existingAppointment = GetById(id);

        existingAppointment.AppointmentDateTime = appointmentDateTime;
    }

    public void Unschedule(int id)
    {
        var appointmentToDelete = GetById(id);
        var relatedDoctorAppointments = appointmentToDelete.Doctor.Appointments;

        relatedDoctorAppointments.Remove(appointmentToDelete);
        _appointments.Remove(appointmentToDelete);
    }
}
