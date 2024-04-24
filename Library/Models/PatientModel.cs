/*
 * Author: Sakthi Santhosh
 * Created on: 17/04/2024
 */
using System.Text.RegularExpressions;

namespace Challenge1.Library.Models;

public class Patient
{
    private int _id;
    private string _name;
    private string _contactNumber;

    public int Id
    {
        get { return _id; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("ID must be a positive integer.");
            _id = value;
        }
    }

    public string Name
    {
        get { return _name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be null or empty.");
            _name = value;
        }
    }

    public string ContactNumber
    {
        get { return _contactNumber; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Contact number cannot be null or empty.");

            string pattern = @"^\+91\s\d{5}\s\d{5}$";

            if (!Regex.IsMatch(value, pattern))
                throw new ArgumentException("Contact number not following the format \"+91 XXXXX XXXXX\".");
            _contactNumber = value;
        }
    }
}
