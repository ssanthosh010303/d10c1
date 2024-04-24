/*
 * Author: Sakthi Santhosh
 * Created on: 22/04/2024
 */
namespace Challenge1.Library.Exceptions;

public class DoctorNotFoundException : Exception
{
    public DoctorNotFoundException() : base()
    {
    }

    public DoctorNotFoundException(string message) : base(message)
    {
    }

    public DoctorNotFoundException(string message, Exception inner) : base(message, inner)
    {
    }

    public DoctorNotFoundException(int id) : base($"A doctor with ID {id} is not found.")
    {
    }
}

public class DoctorAlreadyExistsException : Exception
{
    public DoctorAlreadyExistsException() : base()
    {
    }

    public DoctorAlreadyExistsException(string message) : base(message)
    {
    }

    public DoctorAlreadyExistsException(string message, Exception inner) : base(message, inner)
    {
    }

    public DoctorAlreadyExistsException(int id) : base($"A doctor with ID {id} already exists.")
    {
    }
}
