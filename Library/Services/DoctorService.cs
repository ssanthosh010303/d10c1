/*
 * Author: Sakthi Santhosh
 * Created on: 22/04/2024
 */
using Challenge1.Library.Models;
using Challenge1.Library.Repositories;

namespace Challenge1.Library.Services;

public interface IDoctorService
{
    Doctor? GetDoctorById(int id);
    IEnumerable<Doctor> GetAllDoctors();
    void AddDoctor(int id, string name, string specialization);
    void UpdateDoctor(int id, string name, string specialization);
    void DeleteDoctor(int id);
    bool IsDoctorAvailable(int doctorId, DateTime appointmentDateTime);
    Patient? GetPatientDetailsAtScheduledTime(int doctorId, DateTime appointmentDateTime);
}

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;

    public DoctorService(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public Doctor? GetDoctorById(int id)
    {
        return _doctorRepository.GetById(id);
    }

    public IEnumerable<Doctor> GetAllDoctors()
    {
        return _doctorRepository.GetAll();
    }

    public void AddDoctor(int id, string name, string specialization)
    {
        _doctorRepository.Add(id, name, specialization);
    }

    public void UpdateDoctor(int id, string name, string specialization)
    {
        _doctorRepository.Update(id, name, specialization);
    }

    public void DeleteDoctor(int id)
    {
        _doctorRepository.Delete(id);
    }

    public Patient? GetPatientDetailsAtScheduledTime(int doctorId, DateTime appointmentDateTime)
    {
        var doctor = _doctorRepository.GetById(doctorId);

        if (doctor != null)
            return doctor.Appointments.Find(
                appointmentAtIndex => appointmentAtIndex.AppointmentDateTime == appointmentDateTime)?.Patient;

        return null;
    }

    public bool IsDoctorAvailable(int doctorId, DateTime appointmentDateTime)
    {
        var doctor = _doctorRepository.GetById(doctorId);

        return doctor != null && !_doctorRepository.GetAll().Any(doctor => doctor.Id == doctorId
            && doctor.Appointments.Any(appointment => appointment.AppointmentDateTime == appointmentDateTime));
    }
}
