package com.javalec.ex;

// 클래스 -> 자바빈 -> "DTO"
public class UserDTO {
	private String name;
	private int age;
	
	// getter setter 함수
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public int getAge() {
		return age;
	}
	public void setAge(int age) {
		this.age = age;
	}
	
}