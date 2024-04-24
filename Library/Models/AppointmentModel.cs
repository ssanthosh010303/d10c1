/*
 * Author: Sakthi Santhosh
 * Created on: 17/04/2024
 */
namespace Challenge1.Library.Models;

public class Appointment
{
    private int _id;
    private Doctor _doctor;
    private Patient _patient;
    private DateTime _appointmentDateTime;

    public int Id
    {
        get { return _id; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Appointment ID must be greater than zero.");
            _id = value;
        }
    }

    public Doctor Doctor
    {
        get { return _doctor; }
        set
        {
            _doctor = value ?? throw new ArgumentNullException(nameof(Doctor), "Doctor cannot reference to null.");
        }
    }

    public Patient Patient
    {
        get { return _patient; }
        set
        {
            _patient = value ?? throw new ArgumentNullException(nameof(Patient), "Patient cannot reference to null.");
        }
    }

    public DateTime AppointmentDateTime
    {
        get { return _appointmentDateTime; }
        set
        {
            if (value < DateTime.Now)
                throw new ArgumentException("Appointment must be scheduled in the future.");
            _appointmentDateTime = value;
        }
    }
}
