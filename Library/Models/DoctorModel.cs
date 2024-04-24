/*
 * Author: Sakthi Santhosh
 * Created on: 17/04/2024
 */
namespace Challenge1.Library.Models;

public class Doctor
{
    private int _id;
    private string _name;
    private string _specialization;
    private List<Appointment> _appointments = [];

    public int Id
    {
        get { return _id; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Doctor ID must be greater than 0.");
            _id = value;
        }
    }

    public string Name
    {
        get { return _name; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Doctor name cannot be null or empty.");
            _name = value;
        }
    }

    public string Specialization
    {
        get { return _specialization; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Doctor specialization cannot be null or empty.");
            _specialization = value;
        }
    }

    public List<Appointment> Appointments
    {
        get { return _appointments; }
    }

    public void SetAppointment(Appointment appointment)
    {
        _appointments.Add(appointment);
    }
}
