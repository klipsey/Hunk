﻿using UnityEngine.Networking;
using R2API.Networking;
using R2API.Networking.Interfaces;
using UnityEngine;
using RoR2;

namespace HunkMod.Modules.Components
{
    internal class SyncCaseItem : INetMessage
    {
        private NetworkInstanceId netId;
        private int index;
        private int chestType;

        public SyncCaseItem()
        {
        }

        public SyncCaseItem(NetworkInstanceId netId, int index, int chestType)
        {
            this.netId = netId;
            this.index = index;
            this.chestType = chestType;
        }

        public void Deserialize(NetworkReader reader)
        {
            this.netId = reader.ReadNetworkId();
            this.index = reader.ReadInt32();
            this.chestType = reader.ReadInt32();
        }

        public void OnReceived()
        {
            GameObject bodyObject = Util.FindNetworkObject(this.netId);
            if (!bodyObject) return;

            WeaponChest chest = bodyObject.GetComponent<WeaponChest>();
            if (chest)
            {
                chest.FinishInit(this.index, this.chestType);
                //Chat.AddMessage("Case item was set to " + this.index.ToString());
            }
        }

        public void Serialize(NetworkWriter writer)
        {
            writer.Write(this.netId);
            writer.Write(this.index);
            writer.Write(this.chestType);
        }
    }
}