Object:subClass("PackageItem")

PackageItem.obj=nil
PackageItem.itemImage=nil
PackageItem.numberText=nil

function PackageItem:Setup(data,num,parentTransfom)
    self.obj=GameObject.Instantiate(abManagerInstance:LoadAsset("ui","PackageItem",typeof(GameObject)))
    
    self.itemImage=self.obj.transform:Find("ItemImage"):GetComponent(typeof(Image))
    self.numberText=self.obj.transform:Find("Text"):GetComponent(typeof(Text))
    
    local iconStr=string.split(data.icon,"_")
    local spriteAtlas=abManagerInstance:LoadAsset("ui",iconStr[1],typeof(SpriteAtlas))

    packageItem.itemImage.sprite=spriteAtlas:GetSprite(iconStr[2])
    packageItem.numberText.text=num

    self.obj.transform:SetParent(parentTransfom)

    return self.obj
end