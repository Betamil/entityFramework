function list_child_processes () {
    local ppid=$1;
    local current_children=$(pgrep -P $ppid);
    local local_child;
    if [ $? -eq 0 ];
    then
        for current_child in $current_children
        do
          local_child=$current_child;
          list_child_processes $local_child;
          echo $local_child;
        done;
    else
      return 0;
    fi;
}

ps 12285;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 12285 > /dev/null;
done;

for child in $(list_child_processes 12292);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/hugoribeyron/Documents/programation/entityFramework/ReactWebApp/bin/Debug/net7.0/3ab15687c1fe45488309a6833c8279b6.sh;
