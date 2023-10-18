﻿using MovieTicket.Domain.Validation;

namespace MovieTicket.Domain.Entities;

public class User : Entity
{
    public string Email { get; private set; }
    public string Password { get; private set; }
    public bool IsAdmin { get; private set; }
    public string HashedPassword { get; private set; }
    
    public User( string email, string password, bool isAdmin )
    {
        this.ValidateDomain( email, password );
        this.IsAdmin = isAdmin;
    }

    public User(int id, string email, string password, bool isAdmin, string hashedPassword)
    {
        this.ValidateDomain( email, password );
        DomainExceptionValidation.When( id < 0, "Invalid Id value" );
        this.Id = id;
        this.IsAdmin = isAdmin;
        this.HashedPassword = hashedPassword;
    }
    
    public void ValidateDomain( string email, string password )
    {
        DomainExceptionValidation.When( string.IsNullOrEmpty( email ),
            "Invalid email. Email is required" );

        DomainExceptionValidation.When( email.Length < 3,
            "Invalid email. Too short, minimum 3 characters" );
        
        DomainExceptionValidation.When( string.IsNullOrEmpty( password ),
            "Invalid password. Password is required" );
        
        DomainExceptionValidation.When( password.Length < 8,
            "Invalid password. Too short, minimum 8 characters" );
        
        this.Email = email;
        this.Password = password;
    }
}