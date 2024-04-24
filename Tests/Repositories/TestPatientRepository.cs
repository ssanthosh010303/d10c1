/*
 * Author: Sakthi Santhosh
 * Created on: 22/04/2024
 */
using Challenge1.Library.Repositories;
using Challenge1.Library.Exceptions;

namespace Challenge1.Tests.Repositories;

public class PatientRepositoryTests
{
    private IPatientRepository _patientRepository;

    [SetUp]
    public void Setup()
    {
        _patientRepository = new PatientRepository();
    }

    [Test]
    public void TestGetByIdExistingIdReturnsPatient()
    {
        _patientRepository.Add(1, "John Doe", "+91 54875 21563");

        var result = _patientRepository.GetById(1);

        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.Name, Is.EqualTo("John Doe"));
            Assert.That(result.ContactNumber, Is.EqualTo("+91 54875 21563"));
        });
    }

    [Test]
    public void TestGetByIdNonExistingIdThrowsException()
    {
        Assert.Throws<PatientNotFoundException>(() => _patientRepository.GetById(1));
    }

    [Test]
    public void TestGetAllReturnsAllPatients()
    {
        _patientRepository.Add(1, "John Doe", "+91 54875 21563");
        _patientRepository.Add(2, "Jane Smith", "+91 54875 21563");

        var result = _patientRepository.GetAll();

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Has.Count.EqualTo(2));
    }

    [Test]
    public void TestAddNewPatientAddsToRepository()
    {
        _patientRepository.Add(1, "John Doe", "+91 54875 21563");
        Assert.That(_patientRepository.GetAll(), Has.Count.EqualTo(1));
    }

    [Test]
    public void TestAddExistingPatientThrowsException()
    {
        _patientRepository.Add(1, "John Doe", "+91 54875 21563");
        Assert.Throws<PatientAlreadyExistsException>(() => _patientRepository.Add(1, "Jane Smith", "+91 54875 21563"));
    }

    [Test]
    public void TestUpdateExistingPatientUpdatesSuccessfully()
    {
        _patientRepository.Add(1, "John Doe", "+91 54875 21563");
        _patientRepository.Update(1, "Jane Smith", "+91 54875 21563");

        var updatedPatient = _patientRepository.GetById(1);

        Assert.Multiple(() =>
        {
            Assert.That(updatedPatient.Name, Is.EqualTo("Jane Smith"));
            Assert.That(updatedPatient.ContactNumber, Is.EqualTo("+91 54875 21563"));
        });
    }

    [Test]
    public void TestUpdateNonExistingPatientThrowsException()
    {
        Assert.Throws<PatientNotFoundException>(() => _patientRepository.Update(1, "Jane Smith", "+91 54875 21563"));
    }

    [Test]
    public void TestDeleteExistingPatientRemovesFromRepository()
    {
        _patientRepository.Add(1, "John Doe", "+91 54875 21563");
        _patientRepository.Delete(1);
        Assert.That(_patientRepository.GetAll(), Is.Empty);
    }

    [Test]
    public void TestDeleteNonExistingPatientThrowsException()
    {
        Assert.Throws<PatientNotFoundException>(() => _patientRepository.Delete(1));
    }
}
