Console.Write("Enter your password: ");
string? password = Console.ReadLine()?.Trim();

if (string.IsNullOrWhiteSpace(password))
{
    Console.WriteLine("Password cannot be empty or whitespace. Please try again.");
    return;
}

if (password.Length < 6)
{
    Console.WriteLine("Password must be at least 6 characters long. Please try again.");
    return;
}

// 비밀번호 해싱
string hashedPassword = HashPassword(password);
Console.WriteLine($"Hashed Password: {hashedPassword}");


// 비밀번호 해싱된것과 다시 입력후 비교
Console.Write("Enter your recheck password: ");
string? recheckPwd = Console.ReadLine()?.Trim();

if (string.IsNullOrWhiteSpace(recheckPwd))
{
    Console.WriteLine("Password cannot be empty or whitespace. Please try again.");
    return;
}

if (recheckPwd.Length < 6)
{
    Console.WriteLine("Password must be at least 6 characters long. Please try again.");
    return;
}


bool chk = VerifyPassword(recheckPwd, hashedPassword);


if(chk == true)
    Console.WriteLine("Same.");
else
    Console.WriteLine("Diff");

static string HashPassword(string password)
{
    // Salt와 함께 비밀번호를 해싱
    return BCrypt.Net.BCrypt.HashPassword(password);
}

static bool VerifyPassword(string? password, string hashedPassword)
{
    // 입력된 비밀번호와 저장된 해시값을 비교
    return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
}