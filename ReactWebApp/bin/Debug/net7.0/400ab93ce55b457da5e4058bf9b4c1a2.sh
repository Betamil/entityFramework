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

ps 10200;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 10200 > /dev/null;
done;

for child in $(list_child_processes 10204);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/hugoribeyron/Documents/programation/entityFramework/ReactWebApp/bin/Debug/net7.0/400ab93ce55b457da5e4058bf9b4c1a2.sh;
