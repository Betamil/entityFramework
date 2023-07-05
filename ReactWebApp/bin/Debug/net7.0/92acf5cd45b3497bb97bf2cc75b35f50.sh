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

ps 10813;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 10813 > /dev/null;
done;

for child in $(list_child_processes 10816);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/hugoribeyron/Documents/programation/entityFramework/ReactWebApp/bin/Debug/net7.0/92acf5cd45b3497bb97bf2cc75b35f50.sh;
