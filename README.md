# FanDuel
FanDuel depth chart

Build instructions
  - clone the repo
  - under Depth.Chart folder run dotnet restore & dotnet build

Run instructions
  - dotnet publish (this will create the app under /bin/Debug/net6.0/)
  - double click on DepthChart.Function.exe
  - added following commandline options; <add>, <remove>, <backup> and <full>
  -  all unit tests included in DepthChart.Tests project
  - use below commands to test
      - addPlayerToDepthChart
        
        add {"position":"QB",player:{"number":12,"name":"TomBrady"},"depth":0}
        
        add {"position":"QB",player:{"number":11,"name":"BlaineGabbert"},"depth":1}
        
        add {"position":"QB",player:{"number":2,"name":"KyleT"},"depth":2}
        
        add {"position":"LWR",player:{"number":13,"name":"MikeE"},"depth":0}
        
        add {"position":"LWR",player:{"number":1,"name":"Jaelon"},"depth":1}
        
        add {"position":"LWR",player:{"number":10,"name":"Scott"},"depth":2}
        
      - getBackups  
          backup {"position":"QB",player:{"number":12,"name":"TomBrady"}}
        
          backup {"position":"LWR",player:{"number":1,"name":"Jaelon"}}
        
          backup {"position":"QB",player:{"number":13,"name":"MikeE"}}
        
      - removePlayerFromDepthChart
        
          remove {"position":"LWR",player:{"number":13,"name":"MikeE"}}
        
      - getFullDepthChart
          full

  Assumtions
    - I haven't spent much time on implementing commandline options/instructions, handling different user scenarios.
    - getFullDepthChart call in the following scenario not handled; 
          empty player in above positions. Eg: if we add player with out a position_depth, it will go to the last position and then if we run 'getFullDepthChart'

  Project structure
    - NFLTeamModel -> implements DepthChart for a team
    - NFLDepthChartService -> responsible for performing DepthChart operation on a team level
