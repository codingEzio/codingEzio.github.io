
**context**

- I used to use full-fledged VMs
- I wanna try running a full Linux OS in/as a Docker container
  - Real Linux instead of the macOS
  - Easier to manage (Docker API)
  - Lighter (I don't need the GUI)

-----

**setup the base environment**

```bash
# Get your own via 'brew install --cask vagrant'
vagrant init bento/ubuntu-22.04
vagrant up

mkdir -p ~/VMs && cd ~/VMs

# Intialize the VM
vagrant init bento/ubuntu-22.04  # you may wanna edit the Vagrantfile
vagrant up
```

```ruby
# If you happen to use VirtualBox and turned on the GUI
# You could just open the VirtualBox app and stay there from now on

config.vm.provider "virtualbox" do |vb|
  # Display the VirtualBox GUI when booting the machine
  vb.gui = true

  # Customize the amount of memory on the VM:
  vb.memory = "2024"
end
```
