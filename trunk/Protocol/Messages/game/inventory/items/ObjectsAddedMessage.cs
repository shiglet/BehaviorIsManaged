// File generated by 'DofusProtocolBuilder.exe v1.0.0.0'
// From 'ObjectsAddedMessage.xml' the '27/06/2012 15:55:11'
using System;
using BiM.Core.IO;
using System.Collections.Generic;
using System.Linq;
using BiM.Core.Network;

namespace BiM.Protocol.Messages
{
	public class ObjectsAddedMessage : NetworkMessage
	{
		public const uint Id = 6033;
		public override uint MessageId
		{
			get
			{
				return 6033;
			}
		}
		
		public Types.ObjectItem[] @object;
		
		public ObjectsAddedMessage()
		{
		}
		
		public ObjectsAddedMessage(Types.ObjectItem[] @object)
		{
			this.@object = @object;
		}
		
		public override void Serialize(IDataWriter writer)
		{
			writer.WriteUShort((ushort)@object.Count());
			foreach (var entry in @object)
			{
				entry.Serialize(writer);
			}
		}
		
		public override void Deserialize(IDataReader reader)
		{
			int limit = reader.ReadUShort();
			@object = new Types.ObjectItem[limit];
			for (int i = 0; i < limit; i++)
			{
				(@object as Types.ObjectItem[])[i] = new Types.ObjectItem();
				(@object as Types.ObjectItem[])[i].Deserialize(reader);
			}
		}
	}
}
