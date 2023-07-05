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

ps 10642;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 10642 > /dev/null;
done;

for child in $(list_child_processes 10648);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/hugoribeyron/Documents/programation/entityFramework/ReactWebApp/bin/Debug/net7.0/9eb016a809ce4b2d95a3841300aaedee.sh;
