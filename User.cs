namespace Registration;

public record User(
    int Id,
    string Email,
    string Nickname,
    string FirstName,
    string LastName,
    string Phone,
    DateTime Born
);