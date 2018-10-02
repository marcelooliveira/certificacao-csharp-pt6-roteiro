using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace _01._02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    [Serializable]
    class Diretor : ISerializable
    {
        public string Nome { get; set; }

        protected Diretor(SerializationInfo info, StreamingContext context)
        {
            Nome = info.GetString("nome");
        }

        protected Diretor()
        {
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("nome", Nome);
        }

        [OnSerializing()]
        internal void OnSerializingMethod(StreamingContext context)
        {
            Console.WriteLine("Chamado antes da serialização do diretor");
        }

        [OnSerialized()]
        internal void OnSerializedMethod(StreamingContext context)
        {
            Console.WriteLine("Chamado depois da serialização do diretor");
        }

        [OnDeserializing()]
        internal void OnDeserializingMethod(StreamingContext context)
        {
            Console.WriteLine("Chamado antes da serialização do diretor");
        }

        [OnDeserialized()]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            Console.WriteLine("Chamado depois da serialização do diretor");
        }
    }
}
