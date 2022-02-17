using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CursoWindowsFormsBiblioteca.Databases
{
    public class Fichario
    {

        public string diretorio;
        public string mensagem;
        public bool status;

        public Fichario (string Diretorio)
        {
            status = true;
            try
            {
                if (!(Directory.Exists(Diretorio)))
                {
                    Directory.CreateDirectory(Diretorio);
                }
                diretorio = Diretorio;
                mensagem = "Conexão com o Fichario criada com sucesso.";
            }
            catch( Exception ex)
            {
                status = false;
                mensagem = "Conexão com o Fichario com erro: " + ex.Message;
            }
          
        }

        public void Incluir(string Id, string jsonUnit)
        {
            status = true;
            try
            {
                if (File.Exists(diretorio + "\\" + Id + ".json"))
                {
                    status = false;
                    mensagem = "Inclusão não permitida porque o identificador já existe: " + Id;
                }
                else
                {
                    File.WriteAllText(diretorio + "\\" + Id + ".json", jsonUnit);
                    status = true;
                    mensagem = "Inclusão efetuada com sucesso. Identificador: " + Id;
                }
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com o Fichario com erro: " + ex.Message;
            }       

        }

        public string Buscar(string Id)
        {
            status = true;
            try
            {
                if (!(File.Exists(diretorio + "\\" + Id + ".json")))
                {
                    status = false;
                    mensagem = "Identificador não existente: " + Id;
                }
                else
                {
                    string conteudo = File.ReadAllText(diretorio + "\\" + Id + ".json");
                    status = true;
                    mensagem = "Inclusão efetuada com sucesso. Identificador: " + Id;
                    return conteudo;
                }
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar o conteúdo do identificador: " + ex.Message;
            }
            return "";
        }

        public List<string> BuscarTodos()
        {
            status = true;
            List<string> List = new List<string>();
            try
            {
                var Arquivos = Directory.GetFiles(diretorio, "*.json");
                for (int i = 0; i <= Arquivos.Length - 1; i++)
                {
                    string conteudo = File.ReadAllText(Arquivos[i]);
                    List.Add(conteudo);
                }
                return List;
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar o conteúdo do identificador: " + ex.Message;
            }
            return List;
        }

        public void Apagar (string Id)
        {
            status = true;
            try
            {
                if (!(File.Exists(diretorio + "\\" + Id + ".json")))
                {
                    status = false;
                    mensagem = "Identificador não existente: " + Id;
                }
                else
                {
                    File.Delete(diretorio + "\\" + Id + ".json");
                    status = true;
                    mensagem = "Exclusão efetuada com sucesso. Identificador: " + Id;
                }
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Erro ao buscar o conteúdo do identificador: " + ex.Message;
            }
        }

        public void Alterar(string Id, string jsonUnit)
        {
            status = true;
            try
            {
                if (!(File.Exists(diretorio + "\\" + Id + ".json")))
                {
                    status = false;
                    mensagem = "Alteração não permitida porque o identificador não existe: " + Id;
                }
                else
                {
                    File.Delete(diretorio + "\\" + Id + ".json");
                    File.WriteAllText(diretorio + "\\" + Id + ".json", jsonUnit);
                    status = true;
                    mensagem = "Inclusão efetuada com sucesso. Identificador: " + Id;
                }
            }
            catch (Exception ex)
            {
                status = false;
                mensagem = "Conexão com o Fichario com erro: " + ex.Message;
            }

        }
    }
}
