# referencia
https://www.tutorialkart.com/apache-kafka/install-apache-kafka-on-mac/

# .bashrc
## zookeeper = faz gestão de sistemas distribuidos, ajuda na gestão dos clusters, feito pela apache
``` bash
alias "start_zookeeper= sh ~/kafka_2.13-3.1.0/bin/zookeeper-server-start.sh ~/kafka_2.13-3.1.0/config/zookeeper.properties" 
alias "start_kafka= sh ~/kafka_2.13-3.1.0/bin/kafka-server-start.sh ~/kafka_2.13-3.1.0/config/server.properties" 
```

# no terminal rodar 
``` bash
start_zookeeper
start_kafka
dotnet run
```




