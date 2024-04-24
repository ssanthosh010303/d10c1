/*
 * Author: Sakthi Santhosh
 * Created on: 17/04/2024
 */
using Challenge1.Library.Exceptions;
using Challenge1.Library.Models;

namespace Challenge1.Library.Repositories;

public interface IDoctorRepository
{
    Doctor GetById(int id);
    List<Doctor> GetAll();
    void Add(int id, string name, string specialization);
    void Update(int id, string name, string specialization);
    void Delete(int id);
}

public class DoctorRepository : IDoctorRepository
{
    private readonly List<Doctor> _doctors;

    public DoctorRepository()
    {
        _doctors = [];
    }

    public Doctor GetById(int id)
    {
        var doctor = _doctors.Find(doctorAtIndex => doctorAtIndex.Id == id) ?? throw new DoctorNotFoundException(id);

        return doctor;
    }

    public List<Doctor> GetAll()
    {
        return _doctors;
    }

    public void Add(int id, string name, string specialization)
    {
        if (!_doctors.Any(doctor => doctor.Id == id))
            _doctors.Add(new Doctor { Id = id, Name = name, Specialization = specialization });
        else
            throw new DoctorAlreadyExistsException(id);
    }

    public void Update(int id, string name, string specialization)
    {
        var existingDoctor = GetById(id);

        existingDoctor.Name = name;
        existingDoctor.Specialization = specialization;
    }

    public void Delete(int id)
    {
        var doctorToDelete = GetById(id);

        _doctors.Remove(doctorToDelete);
    }
}
