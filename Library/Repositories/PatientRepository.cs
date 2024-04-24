/*
 * Author: Sakthi Santhosh
 * Created on: 17/04/2024
 */
using Challenge1.Library.Exceptions;
using Challenge1.Library.Models;

namespace Challenge1.Library.Repositories;

public interface IPatientRepository
{
    Patient GetById(int id);
    List<Patient> GetAll();
    void Add(int id, string name, string contactNumber);
    void Update(int id, string name, string contactNumber);
    void Delete(int id);
}

public class PatientRepository : IPatientRepository
{
    private readonly List<Patient> _patients;

    public PatientRepository()
    {
        _patients = [];
    }

    public Patient GetById(int id)
    {
        var patient = _patients.Find(patient => patient.Id == id) ?? throw new PatientNotFoundException(id);

        return patient;
    }

    public List<Patient> GetAll()
    {
        return _patients;
    }

    public void Add(int id, string name, string contactNumber)
    {
        if (!_patients.Any(patient => patient.Id == id))
            _patients.Add(new Patient { Id = id, Name = name, ContactNumber = contactNumber });
        else
            throw new PatientAlreadyExistsException(id);
    }

    public void Update(int id, string name, string contactNumber)
    {
        var existingPatient = GetById(id);

        existingPatient.Name = name;
        existingPatient.ContactNumber = contactNumber;
    }

    public void Delete(int id)
    {
        var patientToDelete = GetById(id);

        _patients.Remove(patientToDelete);
    }
}
