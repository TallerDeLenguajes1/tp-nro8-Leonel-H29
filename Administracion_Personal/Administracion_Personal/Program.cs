using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Administracion_Personal;

namespace Admimistracion_Personal
{
    class Program
    {
        static void Main(string[] args){
            //List<Empleados> Personas = new List<Empleados>();
            Empleados dat_emp = new Empleados();

            //Fecha actual
            DateTime Hoy = DateTime.Now;
            String F_Act = Convert.ToString(Hoy);
            Console.WriteLine("Fecha de hoy: {0}", F_Act);

            //------------------------------AGREGAR EMPLEADOS 
            //Agregar_Emp(Personas);
            dat_emp = Agregar_Emp();
            dat_emp.Mostrar();
            //Menu(Personas, F_Act);

            Console.ReadKey();
        }
        enum Nombres_Hombres { Javier, Luis, Ramon, Carlos, Pablo, Santiago, Ricardo, Alejandro, Nahuel, Agustin };
        enum Nombres_Mujeres { Maria, Carolina, Rocio, Celeste, Patricia, Lourdes, Mirtha, Micaela, Antonela, Carmen };
        enum Apelllidos { Sosa, Luna, Diaz, Herrera, Martinez, Jerez, Nieva, Cardozo, Brito, Villa};
        enum Genero{Masculino, Femenino};
        enum Estado_Civil { Casado, Soltero, Casada, Soltera };


        //------------------------------AGREGAR EMPLEADOS
        static Empleados Agregar_Emp(){
            Empleados dat_emp = new Empleados();
            //int cant_Per = 20;
            Random aleatorio = new Random();

            //Genero
            dat_emp._Genero = Genero_Per();

            //Nombre segun el genero
            if ((dat_emp._Genero).Contains("Masculino") == true)
            {
                int Opcion_Nombre = aleatorio.Next(0, 9);
                Nombres_Hombres Nombre = (Nombres_Hombres)Opcion_Nombre;
                dat_emp.Nombre = Convert.ToString(Nombre);
                int Opcion_Civil = aleatorio.Next(0, 1);
                Estado_Civil Estado = (Estado_Civil)Opcion_Civil;
                dat_emp.Estado_Civil = Convert.ToString(Estado);
            }
            else
            {
                int Opcion_Nombre = aleatorio.Next(0, 9);
                Nombres_Mujeres Nombre = (Nombres_Mujeres)Opcion_Nombre;
                dat_emp.Nombre = Convert.ToString(Nombre);
                int Opcion_Civil = aleatorio.Next(2, 3);
                Estado_Civil Estado = (Estado_Civil)Opcion_Civil;
                dat_emp.Estado_Civil = Convert.ToString(Estado);
            }

            //Apellido
            int Opcion_Apellido = aleatorio.Next(0, 9);
            Apelllidos Ape = (Apelllidos)Opcion_Apellido;
            dat_emp.Apellido = Convert.ToString(Ape);

            //Fecha de Nacimiento
            DateTime fecha_nac = new DateTime(aleatorio.Next(1955, 2002), aleatorio.Next(1, 12), aleatorio.Next(1, 29));
            dat_emp.Fecha_Nac = fecha_nac;

            //Fecha de ingreso
            DateTime fecha_ing = new DateTime(aleatorio.Next(1980, 2019), aleatorio.Next(1, 12), aleatorio.Next(1, 29));
            while (fecha_nac > fecha_ing)
            {
                fecha_ing = new DateTime(aleatorio.Next(1980, 2019), aleatorio.Next(1, 12), aleatorio.Next(1, 29));
            }
            dat_emp.Fecha_Ingreso = fecha_ing;

            //Sueldo Basico
            dat_emp.Sueldo_Base = (float)aleatorio.Next(10000, 25000);

            //Cargo
            int opcion_cargo = aleatorio.Next(0, 4);
            Trabajo Cargo = (Trabajo)opcion_cargo;
            dat_emp.Cargo = Convert.ToString(Cargo);

            return dat_emp;
        }
        //Veo el Genero
        static string Genero_Per(){
            Random aleatorio = new Random();
            int Opcion= aleatorio.Next(0,1);
            Genero Sexo= (Genero)Opcion;
            string Genero = Convert.ToString(Sexo);  
            return Genero;
        }



        //------------------------------BUSCAR EMPLEADOS
        /*static void Buscar_Emp(List<Empleados> Personas) {
            Console.WriteLine("--Escriba el nombre, apellido o nombre completo: ");
            string nom_bus = Convert.ToString(Console.ReadLine());
            String[] partes_nom = nom_bus.Split(' ');
            //Me fijo que el empleado exista
            while (!Personas.Exists(x => x.nombre == partes_nom[0] || !Personas.Exists(y => y.apellido == partes_nom[1])))
            {
                Console.WriteLine("--No exite el empleado\nIngrese otro nombre\n--Escriba el nombre completo: ");
                nom_bus = Convert.ToString(Console.ReadLine());
                partes_nom = nom_bus.Split(' ');
            }
            Console.WriteLine(Personas.Where(x => x.nombre == partes_nom[0]).FirstOrDefault()); //Busco el empleado
        }*/


        //------------------------------ELIMINAR EMPLEADOS
        /*static void Eliminar_Emp(List<Empleados> Personas){
            Console.WriteLine("--Escriba el nombre completo: ");
            string nom_elim = Convert.ToString(Console.ReadLine());
            String[] partes_nom = nom_elim.Split(' ');
            //Me fijo que el empleado exista
            while (!Personas.Exists(x => x.nombre == partes_nom[0]) || !Personas.Exists(y => y.apellido == partes_nom[1])){
                Console.WriteLine("--No exite el empleado\nIngrese otro nombre\n--Escriba el nombre completo: ");
                nom_elim = Convert.ToString(Console.ReadLine());
                partes_nom = nom_elim.Split(' ');
            }
            Personas.Remove(Personas.Where(x => x.nombre == partes_nom[0]).FirstOrDefault()); //Elimino el empleado
        }*/
        
    }
}
