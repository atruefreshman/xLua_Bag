
local textAsset=abManagerInstance:LoadAsset("json","ItemData",typeof(TextAsset))

local itemJsonList=JsonUtility.decode(textAsset.text)

ItemData = {}
for _,v in pairs(itemJsonList) do
    ItemData[v.id] = v
end