PlayerData={}

PlayerData.equips={}
PlayerData.items={}
PlayerData.gems={}

function PlayerData:Init()
    table.insert(PlayerData.equips,{id=1,num=1})
    table.insert(PlayerData.equips,{id=2,num=2})
    table.insert(PlayerData.items,{id=3,num=3})
    table.insert(PlayerData.items,{id=4,num=3})
    table.insert(PlayerData.gems,{id=5,num=3})
    table.insert(PlayerData.gems,{id=6,num=3})
end