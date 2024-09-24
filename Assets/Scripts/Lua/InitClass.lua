-- 工具类
JsonUtility = require("Tools/JsonUtility")
require("Tools/Object")
require("Tools/SplitTools")

-- Unity/System类别名
GameObject=CS.UnityEngine.GameObject
Resources=CS.UnityEngine.Resources
Transform=CS.UnityEngine.Transform
RectTransform=CS.UnityEngine.RectTransform
SpriteAtlas=CS.UnityEngine.U2D.SpriteAtlas
Vector3=CS.UnityEngine.Vector3
Vector2=CS.UnityEngine.Vector2
UI=CS.UnityEngine.UI
Image=UI.Image
Text=UI.Text
Button=UI.Button
Toggle=UI.Toggle
ScrollRect=UI.ScrollRect
TextAsset=CS.UnityEngine.TextAsset
PrimitiveType=CS.UnityEngine.PrimitiveType

-- 自定义类别名
abManagerInstance=CS.ABManager.Instance

canvasTransform=GameObject.Find("Canvas").transform
