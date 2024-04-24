/*
 * Author: Sakthi Santhosh
 * Created on: 22/04/2024
 */
using Challenge1.Library.Repositories;
using Challenge1.Library.Exceptions;

namespace Challenge1.Tests.Repositories;

public class DoctorRepositoryTests
{
    private IDoctorRepository _doctorRepository;

    [SetUp]
    public void Setup()
    {
        _doctorRepository = new DoctorRepository();
    }

    [Test]
    public void TestGetByIdExistingIdReturnsDoctor()
    {
        _doctorRepository.Add(1, "John Doe", "General Medicine");

        var result = _doctorRepository.GetById(1);

        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.Name, Is.EqualTo("John Doe"));
            Assert.That(result.Specialization, Is.EqualTo("General Medicine"));
        });
    }

    [Test]
    public void TestGetByIdNonExistingIdThrowsException()
    {
        Assert.Throws<DoctorNotFoundException>(() => _doctorRepository.GetById(1));
    }

    [Test]
    public void TestGetAllReturnsAllDoctors()
    {
        _doctorRepository.Add(1, "John Doe", "General Medicine");
        _doctorRepository.Add(2, "Jane Smith", "Pediatrics");

        var result = _doctorRepository.GetAll();

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(_doctorRepository.GetAll(), Has.Count.EqualTo(2));
        });

    }

    [Test]
    public void TestAddNewDoctorAddsToRepository()
    {
        _doctorRepository.Add(1, "John Doe", "General Medicine");
        Assert.That(_doctorRepository.GetAll(), Has.Count.EqualTo(1));
    }

    [Test]
    public void TestAddExistingDoctorThrowsException()
    {
        _doctorRepository.Add(1, "John Doe", "General Medicine");
        Assert.Throws<DoctorAlreadyExistsException>(() => _doctorRepository.Add(1, "Jane Smith", "Pediatrics"));
    }

    [Test]
    public void TestUpdateExistingDoctorUpdatesSuccessfully()
    {
        _doctorRepository.Add(1, "John Doe", "General Medicine");
        _doctorRepository.Update(1, "Jane Smith", "Pediatrics");

        var updatedDoctor = _doctorRepository.GetById(1);

        Assert.Multiple(() =>
        {
            Assert.That(updatedDoctor.Name, Is.EqualTo("Jane Smith"));
            Assert.That(updatedDoctor.Specialization, Is.EqualTo("Pediatrics"));
        });
    }

    [Test]
    public void TestUpdateNonExistingDoctorThrowsException()
    {
        Assert.Throws<DoctorNotFoundException>(() => _doctorRepository.Update(1, "Jane Smith", "Pediatrics"));
    }

    [Test]
    public void TestDeleteExistingDoctorRemovesFromRepository()
    {
        _doctorRepository.Add(1, "John Doe", "General Medicine");
        _doctorRepository.Delete(1);
        Assert.That(_doctorRepository.GetAll(), Is.Empty);
    }

    [Test]
    public void TestDeleteNonExistingDoctorThrowsException()
    {
        Assert.Throws<DoctorNotFoundException>(() => _doctorRepository.Delete(1));
    }
}
