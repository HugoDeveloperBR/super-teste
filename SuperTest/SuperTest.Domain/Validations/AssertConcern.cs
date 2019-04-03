using SuperTest.Domain.Helpers;

namespace SuperTest.Domain.Validations
{
    public static class AssertConcern
    {
       
        public static bool EmailEhValido(string email)
        {
            if (string.IsNullOrEmpty(email) || !StringHelper.EmailEhValido(email))
                return false;

            return true;
        }
    }
}
