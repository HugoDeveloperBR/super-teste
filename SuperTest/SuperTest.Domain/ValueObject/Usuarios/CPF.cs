namespace SuperTest.Domain.ValueObject.Usuarios
{
    public class CPF
    {
        private const int VALOR_MAX_CPF = 11;

        protected CPF() { }

        public CPF(string cpf)
        {
            this.Cpf = cpf;
        }

        public string Cpf { get; private set; }

        public bool Validar()
        {
            return Validar(Cpf);
        }

        public bool Validar(string cpf)
        {
            if (cpf.Length > VALOR_MAX_CPF)
                return false;

            while (cpf.Length != VALOR_MAX_CPF)
                cpf = '0' + cpf;

            var igual = true;
            for (var i = 1; i < VALOR_MAX_CPF && igual; i++)
                if (cpf[i] != cpf[0])
                    igual = false;

            if (igual || cpf == "12345678909")
                return false;

            var numeros = new int[VALOR_MAX_CPF];

            for (var i = 0; i < VALOR_MAX_CPF; i++)
                numeros[i] = int.Parse(cpf[i].ToString());

            var soma = 0;
            for (var i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            var resultado = soma % VALOR_MAX_CPF;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != VALOR_MAX_CPF - resultado)
                return false;

            soma = 0;
            for (var i = 0; i < 10; i++)
                soma += (VALOR_MAX_CPF - i) * numeros[i];

            resultado = soma % VALOR_MAX_CPF;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else if (numeros[10] != VALOR_MAX_CPF - resultado)
                return false;

            return true;
        }
    }
}
