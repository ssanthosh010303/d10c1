/*
 * Author: Sakthi Santhosh
 * Created on: 22/04/2024
 */
using Challenge1.Library.Models;
using Challenge1.Library.Repositories;

namespace Challenge1.Library.Services;

public interface IAppointmentService
{
    Appointment? GetAppointmentById(int id);
    IEnumerable<Appointment> GetAllAppointments();
    void ScheduleAppointment(int id, Doctor doctor, Patient patient, DateTime appointmentDateTime);
    void UpdateAppointmentSchedule(int id, DateTime appointmentDateTime);
    void UnscheduleAppointment(int id);
}

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;

    public AppointmentService(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    public Appointment? GetAppointmentById(int id)
    {
        return _appointmentRepository.GetById(id);
    }

    public IEnumerable<Appointment> GetAllAppointments()
    {
        return _appointmentRepository.GetAll();
    }

    public void ScheduleAppointment(int id, Doctor doctor, Patient patient, DateTime appointmentDateTime)
    {
        _appointmentRepository.Schedule(id, doctor, patient, appointmentDateTime);
    }

    public void UpdateAppointmentSchedule(int id, DateTime appointmentDateTime)
    {
        _appointmentRepository.UpdateSchedule(id, appointmentDateTime);
    }

    public void UnscheduleAppointment(int id)
    {
        _appointmentRepository.Unschedule(id);
    }
}
