using System;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;

namespace Adicionar_valor_a_uma_lista
{
	class Program
	{
		[DllImport("msvcrt.dll")]
		public static extern int system(string format);

		static void Main(string[] args)
		{
			// TESTANDO A FUNCAO

			bool condicao = true;
			string[] lista = new string[0];
			while(condicao == true)
			{
				Console.Write("digite o valor que queira adicionar á lista\nLista: ");
				for(int i = 0; i < lista.Length; i++){
					Console.Write("['"+lista[i]+"']"+", ");
				};
				Console.Write("\n\ndigite: ");
				string valor_inserido = Console.ReadLine();
				lista = adicionar(lista, valor_inserido);
				system("cls");
			}
		}
		
		
		// CRIANDO A FUNCAO		

		static string[] adicionar(string[] array, string valor)
		{
			if(File.Exists("valores.txt") == true)
			{
				system("del valores.txt");
			}
			for(int i = 0; i < array.Length; i++)
			{
				File.AppendAllText("valores.txt", array[i]+"\n");
			};
			File.AppendAllText("valores.txt", valor);
			int tamanho = array.Length+1;
			string[] lista = new string[tamanho];
			lista = File.ReadAllLines("valores.txt");
			system("del valores.txt");
			return lista;
		}
	}
}