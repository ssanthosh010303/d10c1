/*
 * Author: Sakthi Santhosh
 * Created on: 22/04/2024
 */
using Challenge1.Library.Models;

namespace Challenge1.Tests.Models;

public class DoctorTests
{
    [Test]
    public void TestDoctorIdLessThanOrEqualToZeroThrowsArgumentException()
    {
        var doctor = new Doctor();

        Assert.Throws<ArgumentException>(() => doctor.Id = 0);
    }

    [Test]
    public void TestDoctorNameNullOrEmptyThrowsArgumentException()
    {
        var doctor = new Doctor();

        Assert.Throws<ArgumentException>(() => doctor.Name = null);
        Assert.Throws<ArgumentException>(() => doctor.Name = "");
    }

    [Test]
    public void TestDoctorSpecializationNullOrEmptyThrowsArgumentException()
    {
        var doctor = new Doctor();

        Assert.Throws<ArgumentException>(() => doctor.Specialization = null);
        Assert.Throws<ArgumentException>(() => doctor.Specialization = "");
    }

    [Test]
    public void DoctorSetAppointmentAddsAppointmentToList()
    {
        var doctor = new Doctor();
        var appointment = new Appointment();

        doctor.SetAppointment(appointment);
        Assert.That(doctor.Appointments, Does.Contain(appointment));
    }
}
