using System;
using System.Globalization;

public class Address 
{    
    private string _street;
    private string _city;
    private string _stateProvince;
    private string _country;

    public Address(string street, string city, string stateProvince, string country)
    {
        _street = street;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;        
    }

    public bool IsInUSA()
    {
        if (_country.Equals("USA"))
        {
            return true;    
        }
        else
        {
            return false;
        }
    }

    public string GetFullAddress()
    {
        string fullAddress = _street + " " + _city + " " + _stateProvince + " " + _country;
        return fullAddress;
    }
}