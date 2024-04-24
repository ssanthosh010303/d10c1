/*
 * Author: Sakthi Santhosh
 * Created on: 22/04/2024
 */
namespace Challenge1.Library.Exceptions;

public class PatientNotFoundException : Exception
{
    public PatientNotFoundException() : base()
    {
    }

    public PatientNotFoundException(string message) : base(message)
    {
    }

    public PatientNotFoundException(string message, Exception inner) : base(message, inner)
    {
    }

    public PatientNotFoundException(int id) : base($"A patient with ID {id} is not found.")
    {
    }
}

public class PatientAlreadyExistsException : Exception
{
    public PatientAlreadyExistsException() : base()
    {
    }

    public PatientAlreadyExistsException(string message) : base(message)
    {
    }

    public PatientAlreadyExistsException(string message, Exception inner) : base(message, inner)
    {
    }

    public PatientAlreadyExistsException(int id) : base($"A patient with ID {id} already exists.")
    {
    }
}
