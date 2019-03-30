using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace LojaManager
{
    public static class Extensoes
    {
        public static string Serialize(this ClienteAPI obj)
        {
            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ClienteAPI));
            ser.WriteObject(stream1, obj);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            string x = sr.ReadToEnd();
            return x;
        }
        public static ClienteAPI Desserialize(this string obj)
        {
            MemoryStream stream1 = new MemoryStream(Encoding.Unicode.GetBytes(obj));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ClienteAPI), 
                new DataContractJsonSerializerSettings()
                {
                    DateTimeFormat= new DateTimeFormat("yyyy-MM-ddTHH:mm:ss")
                }
            );
            return (ClienteAPI)ser.ReadObject(stream1);

        }
        public static List<ClienteAPI> DesserializeList(this string obj)
        {
            MemoryStream stream1 = new MemoryStream(Encoding.Unicode.GetBytes(obj));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<ClienteAPI>),
                new DataContractJsonSerializerSettings()
                {
                    DateTimeFormat = new DateTimeFormat("yyyy-MM-ddTHH:mm:ss")
                }
            );
            return (List<ClienteAPI>)ser.ReadObject(stream1);

        }

    }

    [DataContract]
    public class ClienteAPI
    {
        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public int Tipo { get; set; }
        [DataMember]
        public DateTime DataCadastro { get; set; }
        [DataMember]
        public object Contatos { get; set; }

        public bool IsNew { get; set; }
        public bool IsModified { get; set; }

        public async Task<string> Get(string cliente)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost/loja/api/clientes/");
            HttpResponseMessage response = await client.GetAsync(cliente);
            HttpContent resposta = response.Content;


            using (StreamReader reader = new StreamReader(await resposta.ReadAsStreamAsync()))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public async Task<string> Put(int Cliente)
        {
            HttpClient client = new HttpClient();

            string x = this.Serialize();
            HttpResponseMessage response = await client.PutAsync("http://localhost/loja/api/clientes/"+ Cliente.ToString(), new StringContent(x, Encoding.UTF8, "application/json"));
            HttpContent resposta = response.Content;


            using (StreamReader reader = new StreamReader(await resposta.ReadAsStreamAsync()))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public async Task<string> Delete(int Cliente)
        {
            HttpClient client = new HttpClient();

            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ClienteAPI));
            ser.WriteObject(stream1, this);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            string x = sr.ReadToEnd();
            HttpResponseMessage response = await client.DeleteAsync("http://localhost/loja/api/clientes/" + Cliente.ToString());



            HttpContent resposta = response.Content;


            using (StreamReader reader = new StreamReader(await resposta.ReadAsStreamAsync()))
            {
                return await reader.ReadToEndAsync();
            }
        }
        public async Task<string> Post()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsJsonAsync("http://localhost/loja/api/clientes", this);

            HttpContent resposta = response.Content;


            using (StreamReader reader = new StreamReader(await resposta.ReadAsStreamAsync()))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }

}
