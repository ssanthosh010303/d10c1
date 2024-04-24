/*
 * Author: Sakthi Santhosh
 * Created on: 22/04/2024
 */
using Challenge1.Library.Repositories;
using Challenge1.Library.Exceptions;
using Challenge1.Library.Models;

namespace Challenge1.Tests.Repositories;

public class AppointmentRepositoryTests
{
    private IAppointmentRepository _appointmentRepository;

    [SetUp]
    public void Setup()
    {
        _appointmentRepository = new AppointmentRepository();
    }

    [Test]
    public void TestGetByIdExistingIdReturnsAppointment()
    {
        var doctor = new Doctor { Id = 1, Name = "Dr. Smith", Specialization = "General Medicine" };
        var patient = new Patient { Id = 1, Name = "John Doe", ContactNumber = "+91 54875 21563" };
        var appointmentDateTime = DateTime.Now.AddMinutes(20);

        _appointmentRepository.Schedule(1, doctor, patient, appointmentDateTime);

        var result = _appointmentRepository.GetById(1);

        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.Doctor, Is.EqualTo(doctor));
            Assert.That(result.Patient, Is.EqualTo(patient));
            Assert.That(result.AppointmentDateTime, Is.EqualTo(appointmentDateTime));
        });

    }

    [Test]
    public void TestGetByIdNonExistingIdThrowsException()
    {
        Assert.Throws<AppointmentNotFoundException>(() => _appointmentRepository.GetById(1));
    }

    [Test]
    public void TestGetAllReturnsAllAppointments()
    {
        var doctor1 = new Doctor { Id = 1, Name = "Dr. Smith", Specialization = "General Medicine" };
        var doctor2 = new Doctor { Id = 2, Name = "Dr. Johnson", Specialization = "Pediatrics" };
        var patient1 = new Patient { Id = 1, Name = "John Doe", ContactNumber = "+91 54875 21563" };
        var patient2 = new Patient { Id = 2, Name = "Jane Smith", ContactNumber = "+91 54875 21563" };
        var appointmentDateTime1 = DateTime.Now.AddHours(3);
        var appointmentDateTime2 = DateTime.Now.AddHours(1);

        _appointmentRepository.Schedule(1, doctor1, patient1, appointmentDateTime1);
        _appointmentRepository.Schedule(2, doctor2, patient2, appointmentDateTime2);

        var result = _appointmentRepository.GetAll();

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Has.Count.EqualTo(2));
    }

    [Test]
    public void TestScheduleNewAppointmentAddsToRepository()
    {
        var doctor = new Doctor { Id = 1, Name = "Dr. Smith", Specialization = "General Medicine" };
        var patient = new Patient { Id = 1, Name = "John Doe", ContactNumber = "+91 54875 21563" };
        var appointmentDateTime = DateTime.Now.AddSeconds(40);

        _appointmentRepository.Schedule(1, doctor, patient, appointmentDateTime);
        Assert.That(_appointmentRepository.GetAll(), Has.Count.EqualTo(1));
    }

    [Test]
    public void TestScheduleExistingAppointmentThrowsException()
    {
        var doctor = new Doctor { Id = 1, Name = "Dr. Smith", Specialization = "General Medicine" };
        var patient = new Patient { Id = 1, Name = "John Doe", ContactNumber = "+91 54875 21563" };
        var appointmentDateTime = DateTime.Now.AddDays(2);

        _appointmentRepository.Schedule(1, doctor, patient, appointmentDateTime);
        Assert.Throws<AppointmentAlreadyExistsException>(() => _appointmentRepository.Schedule(1, doctor, patient, appointmentDateTime));
    }

    [Test]
    public void TestScheduleNotFutureTimeThrowsException()
    {
        var doctor = new Doctor { Id = 1, Name = "Dr. Smith", Specialization = "General Medicine" };
        var patient = new Patient { Id = 1, Name = "John Doe", ContactNumber = "+91 54875 21563" };
        var appointmentDateTime = DateTime.Now;

        Assert.Throws<ArgumentException>(() => _appointmentRepository.Schedule(1, doctor, patient, appointmentDateTime));
    }

    [Test]
    public void TestUpdateScheduleExistingAppointmentUpdatesSuccessfully()
    {
        var doctor = new Doctor { Id = 1, Name = "Dr. Smith", Specialization = "General Medicine" };
        var patient = new Patient { Id = 1, Name = "John Doe", ContactNumber = "+91 54875 21563" };
        var appointmentDateTime1 = DateTime.Now.AddHours(2);
        var appointmentDateTime2 = DateTime.Now.AddHours(1);

        _appointmentRepository.Schedule(1, doctor, patient, appointmentDateTime1);
        _appointmentRepository.UpdateSchedule(1, appointmentDateTime2);

        var updatedAppointment = _appointmentRepository.GetById(1);

        Assert.That(updatedAppointment.AppointmentDateTime, Is.EqualTo(appointmentDateTime2));
    }

    [Test]
    public void TestUpdateScheduleNonExistingAppointmentThrowsException()
    {
        Assert.Throws<AppointmentNotFoundException>(() => _appointmentRepository.UpdateSchedule(1, DateTime.Now));
    }

    [Test]
    public void TestUnscheduleExistingAppointmentRemovesFromRepository()
    {
        var doctor = new Doctor { Id = 1, Name = "Dr. Smith", Specialization = "General Medicine" };
        var patient = new Patient { Id = 1, Name = "John Doe", ContactNumber = "+91 54875 21563" };
        var appointmentDateTime = DateTime.Now.AddHours(2);

        _appointmentRepository.Schedule(1, doctor, patient, appointmentDateTime);
        _appointmentRepository.Unschedule(1);
        Assert.That(_appointmentRepository.GetAll(), Is.Empty);
    }

    [Test]
    public void TestUnscheduleNonExistingAppointmentThrowsException()
    {
        Assert.Throws<AppointmentNotFoundException>(() => _appointmentRepository.Unschedule(1));
    }
}
