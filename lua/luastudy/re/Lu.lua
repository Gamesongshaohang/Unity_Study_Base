
---------------------------------------
-- Date    : 2019.10.7
-- Author  : LIANG
-- Describe: 聊天界面
---------------------------------------

local unpack = unpack
local EventHelper       = UIEventListenerHelper
local BroadcastManager  = require"broadcastmanager"
local gameObject, name, fields
local broadcasts
local delayTimer        --延迟器
local chatMgr           = require"chatmanager"
local tempdata
local CDTimer = 0.1
local Space = 220
local Channel = 0
local Timetab = {}






local monthlabel = 
{
   [1] = GetLocalizedString(60000409),
   [2] = GetLocalizedString(60000410),
   [3] = GetLocalizedString(60000411),
   [4] = GetLocalizedString(60000412),
   [5] = GetLocalizedString(60000413),
   [6] = GetLocalizedString(60000414),
   [7] = GetLocalizedString(60000415),
   [8] = GetLocalizedString(60000416),
   [9] = GetLocalizedString(60000417),
  [10] = GetLocalizedString(60000418),
  [11] = GetLocalizedString(60000419),
  [12] = GetLocalizedString(60000420),
}


local function Sort(item1,item2)
  
end

local function destroy()

end

local function show(params)
end

local function hide()    
end

local function refreshworldchat() --刷新世界聊天
 
    fields.UIScrollView_chat.gameObject:SetActive(true)
    fields.UIList_chatdetail:Clear()
    --LOGY("tempdata",tempdata)
    LOGTT(tempdata)
    if tempdata then
      for k,v in pairs(tempdata) do
          local listItem = fields.UIList_chatdetail:AddListItem()
          LOGY("------------------------")
          local mouth = os.date("%m",v.time/1000)
          local time = os.date("%d %M:%S",v.time/1000)
          --LOGR(GETSERVER_LOCAL_TIME(),v.time/1000)
         listItem.Controls["UILabel_time"].gameObject:SetActive(false) 

          table.insert(Timetab,v.time/1000)
          LOGG("Timetab")
          LOGTT(Timetab)
         -- LOGTT(Timetab)
         --LOGR(GETSERVER_LOCAL_TIME(),v.time/1000)



      if v.roleid == PlayerRole.Instance().m_Id then
              listItem.Controls["UIGroup_left"].gameObject:SetActive(false)  
              listItem.Controls["UISprite_head_upR"].gameObject:SetActive(true)  
          else
              listItem.Controls["UIGroup_right"].gameObject:SetActive(false)
             listItem.Controls["UISprite_head_upL"].gameObject:SetActive(true) 
          end
          -- if v.showtime == 1 then
          --     listItem.Controls["UILabel_time"].gameObject:SetActive(true)
          -- else
          --     listItem.Controls["UILabel_time"].gameObject:SetActive(false)
          -- end         
          
          if v.state == 0 then
              listItem.Controls["UILabel_wordL"].text = v.content
              listItem.Controls["UILabel_wordR"].text = v.content
              listItem.Controls["UILabel_nameL"].text = v.name
              listItem.Controls["UILabel_nameR"].text = v.name
          else
              listItem.Controls["UILabel_wordL"].gameObject:SetActive(false)
              listItem.Controls["UILabel_wordR"].gameObject:SetActive(false)
              listItem.Controls["UILabel_nameL"].text = v.name
              listItem.Controls["UILabel_nameR"].text = v.name
          end
      end  
    end










        
      

    -- listItem.Controls["UILabel_time"].gameObject:SetActive(false)

       --  LOGY(GETSERVER_LOCAL_TIME()-v.time/1000)

       --  if GETSERVER_LOCAL_TIME()-v.time/1000 > 10 then
       -- -- fields.UIList_chatdetail:AddListItem()
       --  local enditem= fields.UIList_chatdetail:AddListItem()
       --   listItem.Controls["UIGroup_left"].gameObject:SetActive(false)
       --     listItem.Controls["UIGroup_right"].gameObject:SetActive(false)  

       --   enditem.Controls["UILabel_time"].text=time
       --   -- listItem.Controls["UILabel_time"].text = monthlabel[tonumber(mouth)]..time
       --   enditem.Controls["UILabel_time"].gameObject:SetActive(true)
       --   LOGR("qqqqqqqqqqqqq")
       --  else
       --   --enditem.Controls["UILabel_time"].gameObject:SetActive(false)
       --  end


       refreshguildchat()

   
 
end 

 function refreshguildchat() --刷新公会聊天
   LOGR("Timetab",#Timetab)
      LOGTT(Timetab)
      for i=1,#Timetab-1 do
             for j=i+1,#Timetab do
               LOGY("i："..i,"j"..j)
               if #Timetab>1 and Timetab[j]-Timetab[i] > 10 then
                LOGB(i,j,Timetab[j],Timetab[i])
                LOGY("qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq")

                local indexitem= fields.UIList_chatdetail:GetItemByIndex(j-1)
                LOGB(indexitem)
                indexitem.Controls["UILabel_time"].text="time"
                indexitem.Controls["UILabel_time"].gameObject:SetActive(true)

              --indexitem.gameObject:SetActive(true)
              end
          end
        end
  
end 

local function refreshcrosschat() --刷新跨服聊天
  
end 

--函数table
-- local funclist = 
-- {
--   [0] = refreshworldchat,
--   [1] = refreshguildchat,
--   [2] = refreshcrosschat,
-- }


local function initlabel()
  --[FFF354]%s[-]
   -- fields.UILabel_ContentInput.text = GetLocalizedString(60000037)
   --fields.UILabel_ContentInput.text=string.format("[6BF520]%d[-]",100)
    fields.UILabel_ContentInput.text=string.format("[6BF520]%s","gfgsgtsdddddddddddddddddddddddddddddddddddddddd")

    fields.UILabel_send.text = GetLocalizedString(60000040)
    fields.UIList_chattype:GetItemByIndex(0).Controls["UILabel_item"].text = GetLocalizedString(60000035)
    fields.UIList_chattype:GetItemByIndex(1).Controls["UILabel_item"].text = GetLocalizedString(60000036)
    fields.UIList_chattype:GetItemByIndex(2).Controls["UILabel_item"].text = GetLocalizedString(60000041)   
    fields.UILabel_type.text = GetLocalizedString(60000081)
end

local function refresh(params)
  LOGR("you")
  LOGR("you",you)
end

local function AddMsg(msg,index)
   
  

end

local function update()
end

local function init(params)
    LOGY("init")
    name, gameObject, fields = unpack(params)
    --isemaij=chatMgr.getIsemaij()
   -- LOGR(isemaij)
   -- chatMgr.setIsemaij(true)
    
    
    tempdata = chatMgr.GetChatDate()
    --tempdata1 = chatMgr.GetChatDate1()
  

    -- delayTimer = FrameTimer.New(function()      --延迟执行滑动Scrollview到底函数
    --     
    -- end, 5, 0)
    -- delayTimer:Start()

    --funclist[0]()   --初始聊天为世界窗口

   
 refreshworldchat()
     
 
    
    EventHelper.SetClick(fields.UISprite_close,function()
        G_UIManager.hide(name)
    end)

    EventHelper.SetClick(fields.UIButton_send,function()
      LOGR("发送")
      local infochat = fields.UIInput_chat.value
      if #infochat < 1 or #infochat > 50 then
        G_UIManager.ShowSystemFlyText("Input Two Long Or Nothing") 
        fields.UIInput_chat.value = ""
        return
      end

      chatMgr.SendCAddChatMSG(0,0,fields.UIInput_chat.value,0,0) 
         -- chatMgr.SendCChate(fields.UIInput_chat)     
      fields.UIInput_chat.value = ""
    end)  

end

local function showdialog(params)
end

local function uishowtype()
    return UIShowType.Refresh
end

return {
  init          = init,
  show          = show,
  hide          = hide,
  destroy       = destroy,
  refresh       = refresh,
  update        = update,
  uishowtype    = uishowtype,
  showdialog    = showdialog,
  ShowContents  = ShowContents,
  AddMsg        = AddMsg,
}
