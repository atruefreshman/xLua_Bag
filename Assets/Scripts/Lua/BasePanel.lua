
Object:subClass("BasePanel")

BasePanel.panelObj=nil

function BasePanel:Init()
    if self.panelObj==nil then
        
    end
end

function BasePanel:OpenPanel()
    self.Init()
    self.panelObj.SetActive(true)
end

function BasePanel:ClosePanel()
    self.panelObj.SetActive(false)
end