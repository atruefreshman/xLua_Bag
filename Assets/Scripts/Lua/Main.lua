
print("Mian.lua执行")

require("InitClass")

require("Data/ItemData")

require("Data/PlayerData")
PlayerData.Init()

require("MainPanelUI")
MainPanleUI:OpenPanel()

require("PackagePanelUI")

require("PackageItem")