vagrant configure shared folder via `config.vm.synced_folder "data_bridge", "/vagrant_data"` |||| virtualization, vagrant, config
vagrant configure port mapping in INSIDE-aka-virtualized::HOST-aka-macOS via `config.vm.network "forwarded_port", guest: 3306, host: 3307` |||| virtualization, vagrant, config, database
vagrant configure resource via `config.vm.provider "virtualbox" do |vb| vb.memory = "1024" end` |||| virtualization, vagrant, config
vagrant configure network proxy with 'vagrant plugin install vagrant-proxyconf' and 'config.proxy.http(s) = "http://127.0.0.1:7890" config.proxy.no_proxy = "localhost,127.0.0.1"' |||| virtualization, vagrant, config, network
vagrant from launch to destroy via 'vagrant status', 'vagrant suspend(sleep)/up(boot)/halt(shutdown)/reload(reboot)' |||| virtualization, vagrant, config, lifecycle
vagrant make snapshots to backup, preview via 'vagrant snapshot list', create via 'vagrant snapshot NEW_SNAPSHOT_NAME', then 'vagrant snapshot restore SNAP_NAME' (and 'delete SNAP_NAME') |||| virtualization, vagrant, backup, time-machine, snapshot, data
vagrant common images on 'https://app.vagrantup.com/boxes/search', I often use 'vagrant init (centos/7)||(ubuntu/focal64) |||| virtualization, vagrant, image, os
