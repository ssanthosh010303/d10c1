/*
 * Author: Sakthi Santhosh
 * Created on: 22/04/2024
 */
using Challenge1.Library.Models;

namespace Challenge1.Tests.Models;

public class TestAppointmentModel
{
    [Test]
    public void TestAppointmentIdLessThanOrEqualToZeroThrowsArgumentException()
    {
        var appointment = new Appointment();

        Assert.Throws<ArgumentException>(() => appointment.Id = 0);
    }

    [Test]
    public void TestAppointmentDoctorNullThrowsArgumentNullException()
    {
        var appointment = new Appointment();

        Assert.Throws<ArgumentNullException>(() => appointment.Doctor = null);
    }

    [Test]
    public void TestAppointmentPatientNullThrowsArgumentNullException()
    {
        var appointment = new Appointment();

        Assert.Throws<ArgumentNullException>(() => appointment.Patient = null);
    }

    [Test]
    public void TestAppointmentAppointmentDateTimeInThePastThrowsArgumentException()
    {
        var appointment = new Appointment();

        Assert.Throws<ArgumentException>(() => appointment.AppointmentDateTime = DateTime.Now.AddDays(-1));
    }

    [Test]
    public void TestAppointmentAppointmentDateTimeInTheFutureSetsAppointmentDateTime()
    {
        var appointment = new Appointment();
        var futureDate = DateTime.Now.AddDays(1);

        appointment.AppointmentDateTime = futureDate;
        Assert.That(appointment.AppointmentDateTime, Is.EqualTo(futureDate));
    }
}
