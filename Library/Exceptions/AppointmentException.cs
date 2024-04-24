/*
 * Author: Sakthi Santhosh
 * Created on: 22/04/2024
 */
namespace Challenge1.Library.Exceptions;

public class AppointmentNotFoundException : Exception
{
    public AppointmentNotFoundException() : base()
    {
    }

    public AppointmentNotFoundException(string message) : base(message)
    {
    }

    public AppointmentNotFoundException(string message, Exception inner) : base(message, inner)
    {
    }

    public AppointmentNotFoundException(int id) : base($"An appointment with ID {id} is not found.")
    {
    }
}

public class AppointmentAlreadyExistsException : Exception
{
    public AppointmentAlreadyExistsException() : base()
    {
    }

    public AppointmentAlreadyExistsException(string message) : base(message)
    {
    }

    public AppointmentAlreadyExistsException(string message, Exception inner) : base(message, inner)
    {
    }

    public AppointmentAlreadyExistsException(int id) : base($"An appointment with ID {id} already exists.")
    {
    }
}
