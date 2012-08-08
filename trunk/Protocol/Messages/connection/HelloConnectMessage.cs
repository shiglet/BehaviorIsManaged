// File generated by 'DofusProtocolBuilder.exe v1.0.0.0'
// From 'HelloConnectMessage.xml' the '27/06/2012 15:54:55'
using System;
using BiM.Core.IO;
using System.Collections.Generic;
using System.Linq;
using BiM.Core.Network;

namespace BiM.Protocol.Messages
{
	public class HelloConnectMessage : NetworkMessage
	{
		public const uint Id = 3;
		public override uint MessageId
		{
			get
			{
				return 3;
			}
		}
		
		public string salt;
		public sbyte[] key;
		
		public HelloConnectMessage()
		{
		}
		
		public HelloConnectMessage(string salt, sbyte[] key)
		{
			this.salt = salt;
			this.key = key;
		}
		
		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUTF(salt);
			writer.WriteUShort((ushort)key.Count());
			foreach (var entry in key)
			{
				writer.WriteSByte(entry);
			}
		}
		
		public override void Deserialize(IDataReader reader)
		{
			salt = reader.ReadUTF();
			int limit = reader.ReadUShort();
			key = new sbyte[limit];
			for (int i = 0; i < limit; i++)
			{
				(key as sbyte[])[i] = reader.ReadSByte();
			}
		}
	}
}
