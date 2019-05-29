using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Administracion_Personal
{
    public class Empleados
    {
        public string nombre;
        public string apellido;
        public DateTime F_Nac;
        public string Est_Civil;
        public string Genero;
        public DateTime F_Ingreso;
        public float sueldo_Base;
        public string cargo;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string Estado_Civil
        {
            get { return Est_Civil; }
            set { Est_Civil = value; }
        }
        public string _Genero
        {
            get { return Genero; }
            set { Genero = value; }
        }
        public float Sueldo_Base
        {
            get { return sueldo_Base; }
            set { sueldo_Base = value; }
        }

        public string Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }
        public DateTime Fecha_Nac
        {
            get { return F_Nac; }
            set { F_Nac = value; }
        }
        public DateTime Fecha_Ingreso
        {
            get { return F_Ingreso; }
            set { F_Ingreso = value; }
        }


        public void Mostrar()
        {
            Console.WriteLine("--Nombre: {0}", nombre);
            Console.WriteLine("--Apellido: {0}", apellido);
            Console.WriteLine("--Fecha de Nacimiento: {0}", F_Nac.ToShortDateString());
            Console.WriteLine("--Edad: {0}", Edad());
            Console.WriteLine("--Estado Civil: {0}", Est_Civil);
            Console.WriteLine("--Genero: {0}", Genero);
            Console.WriteLine("--Fecha de Ingreso: {0}", F_Ingreso.ToShortDateString());
            Console.WriteLine("--Antiguedad: {0}", Antiguedad());
            Jubilacion();
            Console.WriteLine("--Sueldo Base: ${0}", sueldo_Base);
            Console.WriteLine("--Cargo: {0}", cargo);
            Console.WriteLine("--Salario: ${0}", salario());
        }
        public int Antiguedad()
        {
            DateTime fecha = new DateTime((DateTime.Today - F_Ingreso).Ticks);
            return fecha.Year - 1;
        }

        public int Edad()
        {
            DateTime fecha = new DateTime((DateTime.Today - F_Nac).Ticks);
            return fecha.Year - 1;
        }

        public int Diferencia() {
            DateTime fecha = new DateTime((F_Nac - F_Ingreso).Ticks);
            return fecha.Year - 1;
        }

        public void Jubilacion()
        {
            int edad = Edad();
            int edad_jub=0;
            //Devuelve la cantidad de años restantes para la jubilación del empleado
            if (Genero.Contains("Masculino") == true) edad_jub = 65;
            else edad_jub = 60;

            if (edad_jub < edad) {
                Console.WriteLine("--Jubilacion: Ya esta disponible para el tramite");
            }
            else Console.WriteLine("--Jubilacion: Le faltan {0} anios para el tramite", edad_jub-edad);
        }
        public float salario() {
            float salario = 0;
            float adicional=0;
            Random aleatorio = new Random();
            int cant_hijos;
            int ant = Antiguedad();

            if (Edad() > 24)
            {
                cant_hijos = aleatorio.Next(0, 4);
            }
            else cant_hijos = aleatorio.Next(0, 1);


            //Console.WriteLine("--Cantidad de hijos de {0} {1}: {2}", this.nombre, this.apellido, cant_hijos);

            if (ant < 20)
            {
                adicional += sueldo_Base * ant * (float)0.02;
            }
            else{
                adicional += sueldo_Base * (float)0.25;
            }

            if (cargo.Contains("Ingeniero") == true || cargo.Contains("Especialista") == true)
            {
                adicional *= (float)1.50;
            }
            if (Est_Civil.Contains("Casado") == true || Est_Civil.Contains("Casada") == true)
            {

                if (cant_hijos > 2)
                {
                    adicional += (float)5000;
                }
            }
            salario = sueldo_Base + adicional;

            return salario;
        }

        //Resultado de la busqueda
        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            Console.WriteLine("----Resultados");
            sb.AppendFormat("Nombre: {0}, Apellido: {1},Fecha de Nacimiento: {2}, Estado Civil: {3}, Genero: {4}, Fecha de Ingreso: {5}, Cargo: {6}, Sueldo Base: ${7}", this.nombre, this.apellido, this.F_Nac, this.Est_Civil, this.Genero, this.F_Ingreso, this.cargo, this.sueldo_Base);
            return (sb.ToString());
        }
    }
    enum Trabajo { Auxiliar, Administrativo, Ingeniero, Especialista, Investigador };
}
