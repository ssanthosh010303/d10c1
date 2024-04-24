/*
 * Author: Sakthi Santhosh
 * Created on: 22/04/2024
 */
using Challenge1.Library.Models;

namespace Challenge1.Tests.Models;

public class PatientTests
{
    [Test]
    public void TestIdSetValidIdIdIsSet()
    {
        var patient = new Patient
        {
            Id = 1
        };
        Assert.That(patient.Id, Is.EqualTo(1));
    }

    [Test]
    public void TestIdSetInvalidIdThrowsArgumentException()
    {
        var patient = new Patient();

        Assert.Throws<ArgumentException>(() => patient.Id = 0);
    }

    [Test]
    public void TestNameSetValidNameNameIsSet()
    {
        var patient = new Patient
        {
            Name = "John Doe"
        };
        Assert.That(patient.Name, Is.EqualTo("John Doe"));
    }

    [Test]
    public void TestNameSetNullOrEmptyNameThrowsArgumentException()
    {
        var patient = new Patient();

        Assert.Throws<ArgumentException>(() => patient.Name = null);
        Assert.Throws<ArgumentException>(() => patient.Name = "");
        Assert.Throws<ArgumentException>(() => patient.Name = "    ");
    }

    [Test]
    public void TestContactNumberSetValidContactNumberContactNumberIsSet()
    {
        var patient = new Patient
        {
            ContactNumber = "+91 12345 67890"
        };
        Assert.That(patient.ContactNumber, Is.EqualTo("+91 12345 67890"));
    }

    [Test]
    public void TestContactNumberSetInvalidContactNumberThrowsArgumentException()
    {
        var patient = new Patient();

        Assert.Throws<ArgumentException>(() => patient.ContactNumber = null);
        Assert.Throws<ArgumentException>(() => patient.ContactNumber = "");
        Assert.Throws<ArgumentException>(() => patient.ContactNumber = "    ");
        Assert.Throws<ArgumentException>(() => patient.ContactNumber = "12345");
        Assert.Throws<ArgumentException>(() => patient.ContactNumber = "+91 1234567890");
        Assert.Throws<ArgumentException>(() => patient.ContactNumber = "+91 1234 567890");
        Assert.Throws<ArgumentException>(() => patient.ContactNumber = "+91 12345 678901");
        Assert.Throws<ArgumentException>(() => patient.ContactNumber = "+91 12345678901");
    }
}
