// File generated by 'DofusProtocolBuilder.exe v1.0.0.0'
// From 'InventoryContentMessage.xml' the '27/06/2012 15:55:11'
using System;
using BiM.Core.IO;
using System.Collections.Generic;
using System.Linq;
using BiM.Core.Network;

namespace BiM.Protocol.Messages
{
	public class InventoryContentMessage : NetworkMessage
	{
		public const uint Id = 3016;
		public override uint MessageId
		{
			get
			{
				return 3016;
			}
		}
		
		public Types.ObjectItem[] objects;
		public int kamas;
		
		public InventoryContentMessage()
		{
		}
		
		public InventoryContentMessage(Types.ObjectItem[] objects, int kamas)
		{
			this.objects = objects;
			this.kamas = kamas;
		}
		
		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUShort((ushort)objects.Count());
			foreach (var entry in objects)
			{
				entry.Serialize(writer);
			}
			writer.WriteInt(kamas);
		}
		
		public override void Deserialize(IDataReader reader)
		{
			int limit = reader.ReadUShort();
			objects = new Types.ObjectItem[limit];
			for (int i = 0; i < limit; i++)
			{
				(objects as Types.ObjectItem[])[i] = new Types.ObjectItem();
				(objects as Types.ObjectItem[])[i].Deserialize(reader);
			}
			kamas = reader.ReadInt();
			if ( kamas < 0 )
			{
				throw new Exception("Forbidden value on kamas = " + kamas + ", it doesn't respect the following condition : kamas < 0");
			}
		}
	}
}
