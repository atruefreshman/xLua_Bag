PackagePanelUI={}

PackagePanelUI.panelObj=nil
PackagePanelUI.closeButton=nil
PackagePanelUI.equipmentToggle=nil
PackagePanelUI.itemToggle=nil
PackagePanelUI.gemToggle=nil
PackagePanelUI.content=nil

PackagePanelUI.nowtype=-1
local packageItems=nil

function PackagePanelUI:Init()
    if self.panelObj==nil then
        self.panelObj=GameObject.Instantiate(abManagerInstance:LoadAsset("ui","PackagePanel",typeof(GameObject)))
        self.panelObj.transform:SetParent(canvasTransform,false)
        
        self.closeButton=self.panelObj.transform:Find("BG/CloseButton"):GetComponent("Button")
        self.equipmentToggle=self.panelObj.transform:Find("BG/ToggleGroup/ToggleEquipment"):GetComponent("Toggle")
        self.itemToggle=self.panelObj.transform:Find("BG/ToggleGroup/ToggleItem"):GetComponent("Toggle")
        self.gemToggle=self.panelObj.transform:Find("BG/ToggleGroup/ToggleGem"):GetComponent("Toggle")
        self.content=self.panelObj.transform:Find("BG/Scroll View/Viewport/Content")

        self.closeButton.onClick:AddListener(function()
            self:ClosePanel()
        end)

        self.equipmentToggle.onValueChanged:AddListener(function(isOn)
            if isOn==true then
                self:ChangeType(1)
            end
        end)
        self.itemToggle.onValueChanged:AddListener(function(isOn)
            if isOn==true then
                self:ChangeType(2)
            end
        end)
        self.gemToggle.onValueChanged:AddListener(function(isOn)
            if isOn==true then
                self:ChangeType(3)
            end
        end)
    end
end

function PackagePanelUI:OpenPanel()
    self:Init()
    self.panelObj:SetActive(true)
    if self.nowtype==-1 then
        self:ChangeType(1)
    end
end

function PackagePanelUI:ClosePanel()
    self.panelObj:SetActive(false)
end

function PackagePanelUI:ChangeType(type)
    if type==self.nowtype then
        return
    end
    self.nowtype=type

    if self.packageItems==nil then
        self.packageItems={}
    else
        for _,v in pairs(self.packageItems) do
            GameObject.Destroy(v.obj)
        end
        self.packageItems={}
    end

    local items=nil
    if type==1 then
        items=PlayerData.equips
        print(1)
    elseif type==2 then
        items=PlayerData.items
        print(2)
    elseif type==3 then
        items=PlayerData.gems
        print(3)
    end

    
    for _,v in pairs(items) do
        local data=ItemData[v.id]
        packageItem=PackageItem:new()
        packageItem:Setup(data,v.num,self.content)
        table.insert(self.packageItems,packageItem)
    end

end