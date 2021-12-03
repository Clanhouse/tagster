﻿namespace Tagster.Auth.Services;

public interface IPasswordService
{
    bool IsValid(string hash, string password);
    string Hash(string password);
}
