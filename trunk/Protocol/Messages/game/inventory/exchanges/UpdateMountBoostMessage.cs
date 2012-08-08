// File generated by 'DofusProtocolBuilder.exe v1.0.0.0'
// From 'UpdateMountBoostMessage.xml' the '27/06/2012 15:55:11'
using System;
using BiM.Core.IO;
using System.Collections.Generic;
using System.Linq;
using BiM.Core.Network;

namespace BiM.Protocol.Messages
{
	public class UpdateMountBoostMessage : NetworkMessage
	{
		public const uint Id = 6179;
		public override uint MessageId
		{
			get
			{
				return 6179;
			}
		}
		
		public double rideId;
		public Types.UpdateMountBoost[] boostToUpdateList;
		
		public UpdateMountBoostMessage()
		{
		}
		
		public UpdateMountBoostMessage(double rideId, Types.UpdateMountBoost[] boostToUpdateList)
		{
			this.rideId = rideId;
			this.boostToUpdateList = boostToUpdateList;
		}
		
		public override void Serialize(IDataWriter writer)
		{
			writer.WriteDouble(rideId);
			writer.WriteUShort((ushort)boostToUpdateList.Count());
			foreach (var entry in boostToUpdateList)
			{
				writer.WriteShort(entry.TypeId);
				entry.Serialize(writer);
			}
		}
		
		public override void Deserialize(IDataReader reader)
		{
			rideId = reader.ReadDouble();
			int limit = reader.ReadUShort();
			boostToUpdateList = new Types.UpdateMountBoost[limit];
			for (int i = 0; i < limit; i++)
			{
				(boostToUpdateList as Types.UpdateMountBoost[])[i] = Types.ProtocolTypeManager.GetInstance<Types.UpdateMountBoost>(reader.ReadShort());
				(boostToUpdateList as Types.UpdateMountBoost[])[i].Deserialize(reader);
			}
		}
	}
}
