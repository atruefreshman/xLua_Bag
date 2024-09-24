MainPanleUI={}

MainPanleUI.panelObj=nil
MainPanleUI.packageBtn=nil
MainPanleUI.skillBtn=nil

function MainPanleUI:Init()
    if self.panelObj==nil then
        self.panelObj=GameObject.Instantiate(abManagerInstance:LoadAsset("ui","MainPanel",typeof(GameObject)))
        self.panelObj.transform:SetParent(canvasTransform,false)

        self.packageBtn=self.panelObj.transform:Find("PackageBtn"):GetComponent(typeof(Button))
        self.skillBtn=self.panelObj.transform:Find("SkillBtn"):GetComponent(typeof(Button))
        self.packageBtn.onClick:AddListener(function()
            self:OnPackageBtnClick()
        end)
    end
end

function MainPanleUI:OpenPanel()
    self:Init()
    self.panelObj:SetActive(true)
end

function MainPanleUI:ClosePanel()
    self.panelObj:SetActive(false)
end

function MainPanleUI:OnPackageBtnClick()
    PackagePanelUI:OpenPanel()
end