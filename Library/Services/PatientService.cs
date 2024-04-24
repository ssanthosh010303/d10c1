/*
 * Author: Sakthi Santhosh
 * Created on: 22/04/2024
 */
using Challenge1.Library.Models;
using Challenge1.Library.Repositories;

namespace Challenge1.Library.Services;

public interface IPatientService
{
    Patient? GetPatientById(int id);
    IEnumerable<Patient> GetAllPatients();
    void AddPatient(int id, string name, string contactNumber);
    void UpdatePatient(int id, string name, string contactNumber);
    void DeletePatient(int id);
}

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;

    public PatientService(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public Patient? GetPatientById(int id)
    {
        return _patientRepository.GetById(id);
    }

    public IEnumerable<Patient> GetAllPatients()
    {
        return _patientRepository.GetAll();
    }

    public void AddPatient(int id, string name, string contactNumber)
    {
        _patientRepository.Add(id, name, contactNumber);
    }

    public void UpdatePatient(int id, string name, string contactNumber)
    {
        _patientRepository.Update(id, name, contactNumber);
    }

    public void DeletePatient(int id)
    {
        _patientRepository.Delete(id);
    }
}
