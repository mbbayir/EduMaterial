using Microsoft.AspNetCore.Identity;

namespace EduMaterial.Localisation

    {
        public class ErrorDescription : IdentityErrorDescriber
        {
            public override IdentityError DuplicateUserName(string userName)
            {
                return new() { Code = "DuplicateUserName", Description = $"{userName}, User Name Registired "};
            }
            public override IdentityError DuplicateEmail(string email)
            {
                return new() { Code = "DuplicateEmail", Description = $"{email}, E-Posta adress Registired!" };
            }
            public override IdentityError PasswordRequiresNonAlphanumeric()
            {
                return new() { Code = "PasswordRequiresNonAlphanumeric", Description = "'The password must contain at least one non-alphanumeric character'!" };
            }
            public override IdentityError PasswordRequiresDigit()
            {
                return new() { Code = "PasswordRequiresDigit", Description = "The Password must contain at (1-9) character!" };
            }
            public override IdentityError PasswordTooShort(int length)
            {
                return new() { Code = "PasswordTooShort", Description = $"The Password minumum {length} least character !" };
            }
            public override IdentityError PasswordRequiresLower()
            {
                return new() { Code = "PasswordRequiresLower", Description = $"The password must be with a minimum  ('a'-'z')! lowercase letter" };
            }

            public override IdentityError PasswordRequiresUpper()
            {
                return new() { Code = "PasswordRequiresUpper", Description = $"The Password must be minumum ('A'-'Z') olmalıdır! uppercase letter" };
            }
        }
    }
