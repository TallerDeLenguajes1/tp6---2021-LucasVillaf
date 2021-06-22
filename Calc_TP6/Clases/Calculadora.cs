using System;
using System.Collections.Generic;
using System.Text;


namespace Calc_TP6.Clases
{
    class Calculadora
    {
        private float numero1;
        private float numero2;
        private string operacionRealizada;
        private DateTime fechaHora;
        private string ecuación;

        public float Numero1 { get => numero1; set => numero1 = value; }
        public float Numero2 { get => numero2; set => numero2 = value; }
        public string OperacionRealizada { get => operacionRealizada; set => operacionRealizada = value; }
        public DateTime FechaHora { get => fechaHora; set => fechaHora = value; }
        public string Ecuación { get => ecuación; set => ecuación = value; }

  

        //metodo Calcular
        public float CalcularOperacion(float n1, float n2, string signo)
        {
            float resultado = 0;
            n1 = numero1;
            n2 = numero2;

            Suma nuevaSuma = new Suma();
            Resta nuevaResta = new Resta();
            División nuevaDivisión = new División();
            Producto nuevaMultiplicación = new Producto();

            switch (signo)
            {
                case "+":
                    resultado = nuevaSuma.Sumar(n1, n2);
                    break;

                case "-":
                    resultado = nuevaResta.Restar(n1, n2);
                    break;

                case "x":
                    resultado = nuevaMultiplicación.Multiplicar(n1, n2);
                    break;

                case "/":
                    resultado = nuevaDivisión.Dividir(n1, n2);
                    break;
            }
            return resultado;
        }

        
        
        
    }
}
