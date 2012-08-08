// File generated by 'DofusProtocolBuilder.exe v1.0.0.0'
// From 'StorageObjectsRemoveMessage.xml' the '27/06/2012 15:55:12'
using System;
using BiM.Core.IO;
using System.Collections.Generic;
using System.Linq;
using BiM.Core.Network;

namespace BiM.Protocol.Messages
{
	public class StorageObjectsRemoveMessage : NetworkMessage
	{
		public const uint Id = 6035;
		public override uint MessageId
		{
			get
			{
				return 6035;
			}
		}
		
		public int[] objectUIDList;
		
		public StorageObjectsRemoveMessage()
		{
		}
		
		public StorageObjectsRemoveMessage(int[] objectUIDList)
		{
			this.objectUIDList = objectUIDList;
		}
		
		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUShort((ushort)objectUIDList.Count());
			foreach (var entry in objectUIDList)
			{
				writer.WriteInt(entry);
			}
		}
		
		public override void Deserialize(IDataReader reader)
		{
			int limit = reader.ReadUShort();
			objectUIDList = new int[limit];
			for (int i = 0; i < limit; i++)
			{
				(objectUIDList as int[])[i] = reader.ReadInt();
			}
		}
	}
}
