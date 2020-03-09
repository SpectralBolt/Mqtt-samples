import paho.mqtt.client as mqtt
import time

client = mqtt.Client()

# The callback for when the client receives a CONNACK response from the server.
def on_connect(client, userdata, rc):
    print("Connected with result code "+str(rc))
    # Subscribing in on_connect() means that if we lose the connection and
    # reconnect then subscriptions will be renewed.
    client.subscribe("$SYS/#")

# The callback for when a PUBLISH message is received from the server.
def on_message(client, userdata, msg):
    print(msg.topic+" "+str(msg.payload))

def on_publish(mqttc, obj, mid):
    print("mid: " + str(mid))
    pass


def main():
    print("Connecting to broker... ")
    client.on_connect = on_connect
    client.on_message = on_message
    client.on_publish = on_publish
    client.connect("localhost", 1883, 60)
    while True:
        if client.is_connected:
            x=input("Type a new message:   ")
            client.publish("test/messages", str(x), qos=1)
        else:
            print("Mqtt not connected")
            time.sleep(1)

main()
